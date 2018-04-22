import datetime
import time
import math
import decimal
import boto3

dynamodb = boto3.resource('dynamodb')
AWSThing_table = dynamodb.Table('AWSThing')
AWSThingDATA_table = dynamodb.Table('AWSThingDATA')

def handler(event, context):
    # For debugging purposes, print out event
    print("DEBUG: Received event with data: ")
    print(event)

    # Get current UNIX timestamp
    dts = datetime.datetime.utcnow()
    epochtime = round(time.mktime(dts.timetuple()) + dts.microsecond/1e6)
    print("DEBUG: Current UNIX timestamp: ")
    print(epochtime)
    temp = event['temp']
    soil = event['soil']
    force = event['force']
    rain = event['rain']
    light = event['light']
    insert_entry(event,epochtime)
    calculate_Convert(event, temp, force, rain, soil, light, epochtime)
    send2User(event, temp, force, rain, soil, light, epochtime)
def insert_entry(event,timestamp):
    # Insert item into entries_table
    if event['status'] == -1:
        # Sensor has an issue, do not add other parameters
        AWSThingDATA_table.put_item(Item={
            'status': event['status'],
            'entryUUID': event['entryUUID'],
            'deviceID': event['deviceID'],
            'createdDate': timestamp
        })
    elif event['status'] == 0:
        # Sensor ok
        AWSThingDATA_table.put_item(Item={
            'status': event['status'],
            'entryUUID': event['entryUUID'],
            'deviceID': event['deviceID'],
            'status': event['status'],
            'temp': event['temp'],
            'soil': event['soil'],
            'force': event['force'],
            'rain': event['rain'],
            'light': event['light'],
            'createdDate': timestamp
        })

def calculate_Convert(event, temp, force, rain, soil, light, timestamp):

    # First step: retrieve deviceID from event
    if event['status'] != 0:
        return #ignore this input as the sensor is not responding
    device_id = event['deviceID']

    # Third step: Write results to database
    AWSThing_table.update_item(
        Key={
            'deviceID': device_id
        },
        UpdateExpression='SET lastUpdated = :v1, d_soil = :v2, d_temp = :v3, d_force = :v4, d_light = :v5, d_rain = :v6' ,
        ExpressionAttributeValues={
            ':v1': timestamp,
            ':v2': soil,
            ':v3': temp,
            ':v4': force,
            ':v5': light,
            ':v6': rain
        }
    )

def send2User(event, temp, force, rain, soil, light, epochtime):
        sns = boto3.client(service_name="sns")
        topicArn = 'arn:aws:sns:ap-southeast-1:315300711776:dynamodb'
        #convert all the value to string
        sTemp=format(temp)
        sForce=format(force)
        sRain=format(rain)
        sSoil=format(soil)
        sLight=format(light)
        sendSNS=False
        sendString=""
        tupleString=""
        tempString=""
        if temp > 30:
            sendSNS=True
            tempString ='Warning Temperature is : '+ sTemp +'°„C\n'
            tupleString=""
            tupleString += tupleString.join(tempString)
            sendString+=tupleString
            print(sendString),
 
        if force < 30:
            sendSNS=True
            tempString ='Warning Water is running low . There are '+ sForce +'% remaining\n'
            tupleString=""
            tupleString += tupleString.join(tempString)
            sendString+=tupleString
            print(sendString)

        if rain > 50:
            sendSNS=True
            tempString = 'Warning! raining!\n'
            tupleString=""
            tupleString += tupleString.join(tempString)
            sendString+=tupleString
            print(sendString)
 
        if soil < 20:
            sendSNS=True
            tempString = 'Warning! Soil moisture is too low ; There are :' + sSoil + '% remaining\n',
            tupleString=""
            tupleString += tupleString.join(tempString)
            sendString+=tupleString
 
        if light < 50:
            sendSNS=True
            tempString = 'Warning! Light intensity is too low : ' + sLight + '%\n'
            tupleString=""
            tupleString += tupleString.join(tempString)
            sendString+=tupleString
        
        print(sendString)
        print(sendSNS)
        if sendSNS == True :
            sns.publish(
                TopicArn = topicArn,
                Message =sendString,
            )