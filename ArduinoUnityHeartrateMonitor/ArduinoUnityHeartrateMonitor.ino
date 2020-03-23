/*  
 *  eHealth sensor platform for Arduino and Raspberry from Cooking-hacks.
 *  
 *  Copyright (C) Libelium Comunicaciones Distribuidas S.L. 
 *  http://www.libelium.com 
 *  
 *  This program is free software: you can redistribute it and/or modify 
 *  it under the terms of the GNU General Public License as published by 
 *  the Free Software Foundation, either version 3 of the License, or 
 *  (at your option) any later version. 
 *  a
 *  This program is distributed in the hope that it will be useful, 
 *  but WITHOUT ANY WARRANTY; without even the implied warranty of 
 *  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the 
 *  GNU General Public License for more details.
 *  
 *  You should have received a copy of the GNU General Public License 
 *  along with this program.  If not, see http://www.gnu.org/licenses/. 
 *  
 *  Version:           2.0
 *  Design:            David Gascón 
 *  Implementation:    Luis Martin & Ahmad Saad
 */
 
#include <PinChangeInt.h>
#include <eHealth.h>

int BPM;

int cont = 0;

void setup() 
{
  Serial.begin(115200);
  eHealth.initPulsioximeter();

  //Attach the inttruptions for using the pulsioximeter.
  PCintPort::attachInterrupt(6, readPulsioximeter, RISING);
}

void loop() 
{
  BPM = eHealth.getBPM();

  Serial.print("BPM: ");
  Serial.println(BPM);
  
  delay(100);
}

//Include always this code when using the pulsioximeter sensor
//=========================================================================
void readPulsioximeter()
{
  cont ++;

  //Get only of one 50 measures to reduce the latency
  if (cont == 50)
  { 
    eHealth.readPulsioximeter();
    cont = 0;
  }
}
