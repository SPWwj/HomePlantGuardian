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
#include <Servo.h>

Servo myservo;  // create servo object to control a servo
int pos = 95;    // variable to store the servo position

String inputString = "";         // a string to hold incoming data
boolean stringComplete = false;  // whether the string is complete
String commandString = "";

//Declare pin for moter
int pumpPin = 9;

//init state
boolean isConnected = false;
boolean rectState = false;
boolean pumpState = false;

//Declare Pin for LCD
const int rs = 12, en = 11, d4 = 5, d5 = 4, d6 = 3, d7 = 2;
LiquidCrystal lcd(rs, en, d4, d5, d6, d7);


void setup() {
  Serial.begin(9600);
  myservo.attach(8);  // attaches the servo on pin 9 to the servo object
  pinMode(pumpPin,OUTPUT);
  initDisplay();
  myservo.write(pos);
}

void loop() {

      if(pumpState == true)
    {
      if (pos>5)
      {
        pos-=1;
        myservo.write(pos);
        delay(25);   
       }
    }
    else
    { 
      if (pos<95)
      {
        pos+=1;
        myservo.write(pos);
        delay(25);   
       }
    }   

if(stringComplete)
{
  stringComplete = false;
  getCommand();
  
  if(commandString.equals("STAR"))
  {
    lcd.clear();
    lcd.print("Waiting for instruction");    
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
    if(pumpState == true)
    {
      turnPumpOn(pumpPin);
    }
    else
    {
      turnPumpOff(pumpPin);
    }   
  }
  
  inputString = "";
}

}

void initDisplay()
{
  lcd.begin(16, 2);
  lcd.print("Ready to connect");
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

void getCommand()
{
  if(inputString.length()>0)
  {
     commandString = inputString.substring(1,5);
  }
}

void turnPumpOn(int pin)
{
  digitalWrite(pin,HIGH);
}

void turnPumpOff(int pin)
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

