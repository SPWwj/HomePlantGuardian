# This file is for an AWS Lambda function of the same name
# This Lambda function automatically appends a createdDate property
# to an incoming AWS IoT MQTT update message and writes it into DynamoDB

import datetime
import time
import math
import decimal
import boto3

# Get the service resource and table
dynamodb = boto3.resource('dynamodb')
table = dynamodb.Table('entries')

def lambda_handler(event, context):
    # For debugging purposes, print out event
    print("DEBUG: Received event with data: ")
    print(event)

    # Get current UNIX timestamp
    dts = datetime.datetime.utcnow()
    epochtime = round(time.mktime(dts.timetuple()) + dts.microsecond/1e6)
    print("DEBUG: Current UNIX timestamp: ")
    print(epochtime)

    # Insert item into table
    if event['status'] == -1:
        # Sensor has an issue, do not add other parameters
        table.put_item(Item={
            'entryUUID': event['entryUUID'],
            'status': event['status'],
            'deviceID': event['deviceID'],
            'createdDate': epochtime
        })
    elif event['status'] == 0:
        # Sensor ok
        # Calculate roll and pitch (in degrees) for that sensor value in
        # Formula available here: https://www.nxp.com/docs/en/application-note/AN3461.pdf
        # Roll range: [0, 180], pitch range: [0, 90]
        x = event['accl_x']
        y = event['accl_z'] # z and y are swapped as the sensor is mounted
        z = event['accl_y'] # vertically, not horizontally
        roll = round(abs(math.atan2(y, z))*57.3)
        pitch = round(abs(math.atan2(-x, math.sqrt(y*y + z*z)))*57.3)
        table.put_item(Item={
            'entryUUID': event['entryUUID'],
            'status': event['status'],
            'deviceID': event['deviceID'],
            'accl_x': decimal.Decimal(repr(event['accl_x'])),
            'accl_y': decimal.Decimal(repr(event['accl_y'])),
            'accl_z': decimal.Decimal(repr(event['accl_z'])),
            'gyro_x': decimal.Decimal(repr(event['gyro_x'])),
            'gyro_y': decimal.Decimal(repr(event['gyro_y'])),
            'gyro_z': decimal.Decimal(repr(event['gyro_z'])),
            'roll': roll,
            'pitch': pitch,
            'rain': event['rain'],
            'soil': event['soil'],
            'createdDate': epochtime
        })
