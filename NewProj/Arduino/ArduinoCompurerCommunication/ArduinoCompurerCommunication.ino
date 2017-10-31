/**************** Pin mapping ****************/
/*
 * Rainfall detector
 * VCC_IN  ->   5V
 * GND     ->   GND
 * A0      ->   A0
 * D0      ->   NC
 *
 * Soil Moisture Sensor
 * VCC_IN  ->   5V
 * GND     ->   GND
 * A0      ->   A1
 * D0      ->   NC (no connect)
 * 
 * 
 * Output Pin
 * ServoCover   ->  8
 * Motor        ->  9
 * 
 * LCD
 * rs = 12, en = 11, d4 = 5, d5 = 4, d6 = 3, d7 = 2;
 * 
 */

#include <LiquidCrystal.h>
#include <SoftwareSerial.h>
#include <Servo.h>
//
#define rxPin 0
#define txPin 1
SoftwareSerial esp8266(rxPin, txPin);

Servo myservo;  // create servo object to control a servo

String inputString = "";         // a string to hold incoming data
boolean stringComplete = false;  // whether the string is complete
String commandString = "";

//Declare pin for moter
int pumpPin = 8;
int servoPin=9;

//init state
boolean isConnected = false;
boolean rectState = false;
boolean rainState = false;
boolean pumpState = false;
boolean soilDryState = false;

//Declare Pin for LCD
const int rs = 12, en = 11, d4 = 5, d5 = 4, d6 = 3, d7 = 2;
LiquidCrystal lcd(rs, en, d4, d5, d6, d7);

// Rain and soil moisture values
int rainValue=0, soilMoistureValue=0;
const int SOILTHRESHOLD=1300;
const int RAINTHRESHOLD= 800;

/**************** Main Program ****************/

void setup() {
  // Setup ESP8266 serial port
  Serial.begin(9600);
  esp8266.begin(9600);
  myservo.attach(servoPin);  // attaches the servo on pin 9 to the servo object
  pinMode(pumpPin,OUTPUT);
  myservo.write(95);  
  initDisplay();
  // Setup onboard LED for status indication
  pinMode(LED_BUILTIN, OUTPUT);
}

void loop() {
    readSensors();
    checkThreshold();
    formControl();
    operation();
    send2esp8266();
}

/**************************************serialEvent***************************************************/

void send2esp8266(){
    if (esp8266.available()) {
        // Wait for '.' character
    if (esp8266.read() == '.') {
      // Construct data and send payload
      esp8266.print(soilMoistureValue);
      esp8266.print(',');
      esp8266.print(rainValue);

      // Blink LED to indicate that ESP8266 has requested data
      digitalWrite(LED_BUILTIN, HIGH);
      delay(0.5);
      digitalWrite(LED_BUILTIN, LOW);
    }
  }
}

void serialEvent() {
  while (Serial.available()) {
    // get the new byte:
    char inChar = (char)Serial.read();
    // add it to the inputString:
    inputString += inChar;
    // if the incoming character is a newline, set a flag
    // so the main loop can do something about it:
    if (inChar == '\n') {
      stringComplete = true;
    }
  }
}

/**************** Helper functions ****************/

void readSensors() {
  rainValue = analogRead(A0);
  soilMoistureValue = analogRead(A1);
}

void turnPumpOn(int pin)
{
  digitalWrite(pin,HIGH);
}

void turnPumpOff(int pin)
{
  digitalWrite(pin,LOW);
}

void checkThreshold(){
      if (soilMoistureValue >SOILTHRESHOLD)
    {
      soilDryState=true;
    }
    else
    {
      soilDryState=false;
    }
    if (rainValue<RAINTHRESHOLD)
    {
      rainState=true;
    }
    else
    {
      rainState=false;
    }
}

void initDisplay()
{
  lcd.begin(16, 2);
  lcd.print("Ready to connect");
}

void getCommand()
{
  if(inputString.length()>0)
  {
     commandString = inputString.substring(1,5);
  }
}

boolean getState()
{
  boolean state = false;
  if(inputString.substring(5,7).equals("ON"))
  {
    state = true;
  }else
  {
    state = false;
  }
  return state;
}

String getTextToPrint()
{
  String value = inputString.substring(5,inputString.length()-2);
  return value;
}

void printText(String text)
{
  lcd.clear();
  lcd.setCursor(0,0);
    if(text.length()<16)
    {
      lcd.print(text);
    }else
    {
      lcd.print(text.substring(0,16));
      lcd.setCursor(0,1);
      lcd.print(text.substring(16,32));
    }
}

void formControl(){
if(stringComplete)
{
  stringComplete = false;
  getCommand();
  
  if(commandString.equals("STAR"))
  {
    lcd.clear();
    printText("Waiting for     Instruction");
  }
  if(commandString.equals("STOP"))
  {
    turnPumpOff(pumpPin);
    lcd.clear();
    lcd.print("Ready to connect");    
  }
  else if(commandString.equals("TEXT"))
  {
    String text = getTextToPrint();
    printText(text);
  }
  else if(commandString.equals("RECT"))
  {
    rectState = getState();
  }
  else if(commandString.equals("PUMP"))
  {
    pumpState = getState();
  } 
}
inputString = "";
}

void operation(){

  //if (rainState ==true || rectState==true)
  
  if ( rectState==true)
    {
        myservo.write(5);
    }
  else
    { 
        myservo.write(95);
    }  
  if (pumpState ==true || soilDryState==true)
    {
      turnPumpOn(pumpPin);
    }
    else
    {
      turnPumpOff(pumpPin);
    }  
}


