#include <LiquidCrystal.h>
#include <SoftwareSerial.h>
#include <Servo.h>
//
#define rxPin 0
#define txPin 1
SoftwareSerial esp8266(rxPin, txPin);

String inputString = "";         // a string to hold incoming data
boolean stringComplete = false;  // whether the string is complete
String commandString = "";

Servo myservo;  // create servo object to control a servo

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
    myservo.write(0);  
  initDisplay();
    pinMode(LED_BUILTIN, OUTPUT);
    digitalWrite(LED_BUILTIN,LOW);
}

void loop() {
operation();

if(stringComplete)
{
  stringComplete = false;
  getCommand();
  
  if(commandString.equals("STAR"))
  {
    lcd.clear();
  }
  if(commandString.equals("STOP"))
  {
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
    boolean LedState = getLedState();
    if(LedState == true)
    {
      rectState=true;
    }else
    {
      rectState=false;
    }   
  }
    else if(commandString.equals("LED2"))
  {
    boolean LedState = getLedState();
    if(LedState == true)
    {
    }else
    {

    }   
  }
    else if(commandString.equals("LED3"))
  {
    boolean LedState = getLedState();
    if(LedState == true)
    {

    }else
    {
    }   
  }
  
  inputString = "";
}

}

void operation(){

  //if (rainState ==true || rectState==true)
  
  if ( rectState==true)
    {
        myservo.write(170);
    }
  else
    { 
        myservo.write(90);
    }  
//  if (pumpState ==true || soilDryState==true)
//    {
//      turnPumpOn(pumpPin);
//    }
//    else
//    {
//      turnPumpOff(pumpPin);
//    }  
}

void initDisplay()
{
  lcd.begin(16, 2);
  lcd.print("Ready to connect");
}

boolean getLedState()
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

void getCommand()
{
  if(inputString.length()>0)
  {
     commandString = inputString.substring(1,5);
  }
}

void turnLedOn(int pin)
{
  digitalWrite(pin,HIGH);
}

void turnLedOff(int pin)
{
  digitalWrite(pin,LOW);
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

