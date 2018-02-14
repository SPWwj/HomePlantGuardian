/* 
 * TCP Client using ESP8266 & PIC
 * http://www.electronicwings.com
 */

#include <string.h>
#include <stdio.h>
#include <stdint.h>
#include <stdlib.h>
#include <stdbool.h>
#include <pic18f4550.h>
#include "USART_Header_File.h"
#include "Configuration_header_file.h"

#define DEFAULT_BUFFER_SIZE		160
#define DEFAULT_TIMEOUT			10000

int8_t Response_Status;
volatile int16_t Counter = 0, pointer = 0;
uint32_t TimeOut = 0;
char RESPONSE_BUFFER[DEFAULT_BUFFER_SIZE];


    char mystring[16];   
    
    int temp;
    int soil;
    int force;
    int rain;
    int light;
    
//    char RH_Decimal,RH_Integral,T_Decimal,T_Integral;
//    char Checksum;
//    char value[10]; 
    

#define Data_Out LATA0         /* assign Port pin for data*/
#define Data_In PORTAbits.RA0  /* read data from Port pin*/
#define Data_Dir TRISAbits.RA0 /* Port direction */
#define _XTAL_FREQ 8000000     /* define _XTAL_FREQ for using internal delay */
//    
//void DHT11_Start();
//void DHT11_CheckResponse();
//char DHT11_ReadData();
//



void readSensor()
{
    ADCON0 = 0b00000001;    // bit5-2 0000 select channel 0 conversion 
    ADCON0bits.GO = 1;		// This is bit2 of ADCON0, START CONVERSION NOW    
	while(ADCON0bits.GO == 1); 	// Waiting for DONE 
	temp = ADRESH;			// Displaying only the upper 8-bits
    temp=temp*24/60;
	//temp=temp/255*100;					   		// of the A/D result
    MSdelay(100);
	ADCON0 = 0b00000101;    // bit5-2 0000 select channel 0 conversion 
    ADCON0bits.GO = 1;		// This is bit2 of ADCON0, START CONVERSION NOW        
	while(ADCON0bits.GO == 1); 	// Waiting for DONE 		
	soil = ADRESH;			// Displaying only the upper 8-bits
	soil=(255-soil)*100/255;					   		// of the A/D result
    ADCON0 = 0b00001001;    // bit5-2 0000 select channel 0 conversion 
    ADCON0bits.GO = 1;		// This is bit2 of ADCON0, START CONVERSION NOW        
	while(ADCON0bits.GO == 1); 	// Waiting for DONE 
	force = ADRESH;
    force=(255-force)*100/255;    
    ADCON0 = 0b00001101;    // bit5-2 0000 select channel 0 conversion 
    ADCON0bits.GO = 1;		// This is bit2 of ADCON0, START CONVERSION NOW 
	while(ADCON0bits.GO == 1); 	// Waiting for DONE 		
	rain = ADRESH;
    rain=(255-rain)*100/255;    
    ADCON0 = 0b00010001;    // bit5-2 0000 select channel 0 conversion 
    ADCON0bits.GO = 1;		// This is bit2 of ADCON0, START CONVERSION NOW
	while(ADCON0bits.GO == 1); 	// Waiting for DONE 
	light = ADRESH;
    light=(255-light)*100/250;
    //light=light/255*100;
}

void tackeAction()
{
    if(temp >10) PORTDbits.RD0=1;
    else PORTDbits.RD0 =0;
     
    if(soil <20) PORTDbits.RD1=0;
    else PORTDbits.RD1 =1;
        
    if(force <30) PORTDbits.RD2=1;
    else PORTDbits.RD2 =0;
        
    if(rain <90) PORTDbits.RD3=1;
    else PORTDbits.RD3 =0;
        
    if(light <50) PORTDbits.RD4=0;
    else PORTDbits.RD4 =1;
}

void txSensorsData()
{       
//    sprintf(value,"%d",T_Integral);
//   // LCD_String_xy(1,0,value);
//       USART_SendString(value);
//           USART_SendString(",");
//    sprintf(value,".%d",T_Decimal);
//    LCD_String(value);
//    LCD_Char(0xdf);
//    LCD_Char('C');
//    
//    sprintf(value,"%d  ",Checksum);
//    LCD_String_xy(1,8,value);
    
    sprintf(mystring,"%d",temp);  
    //USART_SendString("temp: ");
    USART_SendString(mystring);
        
    sprintf(mystring,"%d",soil); 
    //USART_SendString(" soil: ");
    USART_SendString(",");
    USART_SendString(mystring);
        
    sprintf(mystring,"%d",force);  
    //USART_SendString(" force: ");
    USART_SendString(",");
    USART_SendString(mystring);
        
    sprintf(mystring,"%d",rain);  
    //USART_SendString(" rain: ");
    USART_SendString(",");
    USART_SendString(mystring);
        
    sprintf(mystring,"%d",light);  
    //USART_SendString(" light: ");
    USART_SendString(",");
    USART_SendString(mystring);
    
    USART_SendString("\n");
}

void interrupt ISR()							/* Receive ISR routine */
{
    uint8_t oldstatus = STATUS;
    INTCONbits.GIE = 0;
    if(RCIF==1){
     if (USART_RxChar()=='.')txSensorsData();
     MSdelay(100);
    }
    INTCONbits.GIE = 1;
    STATUS = oldstatus;
}

int main(void)
{
    //#define HIGH 0xD0   // HIGH water level indicator

	TRISD = 0x00;		// Set PORTD to be output
	PORTD = 0x00;		// Initialise PORTD LEDs to zeros

//	TRISCbits.TRISC1 = 0; 	// RC1 as output pin
// 	PORTCbits.RC1    = 0;   // RC1 is connected to Relay
//
//	TRISCbits.TRISC2 = 0; 	// RC2 as output pin
// 	PORTCbits.RC2    = 0;   // RC2 is connected to Motor

	/* Initialise analog to digital conversion setting */
//
//	ADCON0 = 0b00000001;    // bit5-2 0000 select channel 0 conversion 
//							// bit1	  A/D conversion status bit
//							//	      1- GO to starts the conversion
//							//	      0 - DONE when A/D is completed
//							// bit0   Set to 1 to power up A/D
//
	ADCON1 = 0b00000000;	// bit5   reference is VSS
							// bit4   reference is VDD
							// bit3-0 AN12 to AN0 Analog, the rest Digital

	ADCON2 = 0b00010110;	// bit7   : A/D Result Format. 0 Left, 1 Right justified
							// bit5-3 : 010 acquisition time = 4 TAD
							// bit2-0 : 110 conversion clock = Tosc / 16
    //Above is ADC
    
	char _buffer[150];
    OSCCON = 0x72;                              /* Set internal clock to 8MHz */
 	USART_Init(9600);							/* Initiate USART with 115200 baud rate */
    INTCONbits.GIE=1;                           /* enable Global Interrupt */
    INTCONbits.PEIE=1;                          /* enable Peripheral Interrupt */
    PIE1bits.RCIE=1;                            /* enable Receive Interrupt */	
   unsigned int start =0;
    MSdelay(1000);
//   USART_SendString("Init\n");
    MSdelay(1000);
   
    //    ADCON1=0x0F;    /* this makes all pins as a digital I/O pins */    
    
	while(1)
	{   
//        if (start==0)
//        {
//            start ++;
//            USART_SendString("Helloworld\n");
//        }

        MSdelay(100);
        
//            DHT11_Start();  /* send start pulse to DHT11 module */
//    DHT11_CheckResponse();  /* wait for response from DHT11 module */
//    
//    /* read 40-bit data from DHT11 module */
//    RH_Integral = DHT11_ReadData();  /* read Relative Humidity's integral value */
//    RH_Decimal = DHT11_ReadData();   /* read Relative Humidity's decimal value */
//    T_Integral = DHT11_ReadData();   /* read Temperature's integral value */
//    T_Decimal = DHT11_ReadData();    /* read Relative Temperature's decimal value */
//    Checksum = DHT11_ReadData();     /* read 8-bit checksum value */
        readSensor();
        MSdelay(1000);
       
        
        tackeAction();
        MSdelay(100);		
	}
}
//char DHT11_ReadData()
//{
//  char i,data = 0;  
//    for(i=0;i<8;i++)
//    {
//        while(!(Data_In & 1));  /* wait till 0 pulse, this is start of data pulse */
//        __delay_us(30);         
//        if(Data_In & 1)  /* check whether data is 1 or 0 */    
//          data = ((data<<1) | 1); 
//        else
//          data = (data<<1);  
//        while(Data_In & 1);
//    }
//  return data;
//}
//
//void DHT11_Start()
//{    
//    Data_Dir = 0;  /* set as output port */
//    Data_Out = 0;  /* send low pulse of min. 18 ms width */
//    __delay_ms(18);
//    Data_Out = 1;  /* pull data bus high */
//    __delay_us(20);
//    Data_Dir = 1;  /* set as input port */    
//}
//
//void DHT11_CheckResponse()
//{
//    while(Data_In & 1);  /* wait till bus is High */     
//    while(!(Data_In & 1));  /* wait till bus is Low */
//    while(Data_In & 1);  /* wait till bus is High */
//}
