#include <PinChangeInt.h>
#include <PinChangeIntConfig.h>
#include <eHealth.h>
#include <eHealthDisplay.h>

// count for pulsioximeter
int cont = 0;

void setup() {
  Serial.begin(115200);  
  eHealth.initPulsioximeter();

  //Attach the inttruptions for using the pulsioximeter.   
  PCintPort::attachInterrupt(6, readPulsioximeter, RISING);
}

void loop() 
{
  Serial.println(eHealth.getBPM());
  delay(200);
}


// Include always this code when using the pulsioximeter sensor
// =========================================================================
void readPulsioximeter(){  

  cont ++;

  if (cont == 50) { //Get only of one 50 measures to reduce the latency
    eHealth.readPulsioximeter();  
    cont = 0;
  }
}
