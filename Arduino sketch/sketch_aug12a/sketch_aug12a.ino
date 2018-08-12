void setup() {
  Serial.begin(9600);
  pinMode(9, OUTPUT);
}

bool read_command_complete = false;
String COMMAND;

void loop() {
  if(read_command_complete){
    if(COMMAND.equals("ON")) digitalWrite(9, HIGH);
    if(COMMAND.equals("OFF")) digitalWrite(9, LOW);
    read_command_complete = false;
    COMMAND = "";
  }
}

void serialEvent() {
  while(Serial.available()){
    char symb = (char)Serial.read();
    if(symb == '\n'){
      read_command_complete = true;
      break;
    }
    COMMAND += symb;
  }
}
