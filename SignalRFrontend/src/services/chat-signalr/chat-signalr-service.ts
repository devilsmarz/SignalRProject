import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { HubConnection, HubConnectionBuilder, LogLevel } from '@microsoft/signalr'
import { from } from 'rxjs';
import { tap } from 'rxjs/operators';
import { MessagePackHubProtocol } from '@microsoft/signalr-protocol-msgpack'
import { Message } from 'src/models/message';

@Injectable({
  providedIn: 'root'
})
export class SignalrService {

  private hubConnection: HubConnection;
  public messages: Message[] = [];
  private connectionUrl = 'https://localhost:5001/signalr';
  private apiUrl = 'chat';

  constructor(private http: HttpClient) { this.hubConnection = this.getConnection();}

  public connect = () => {
    this.startConnection();
    this.addListeners();
  }

  public sendMessageToApi(message: Message) {
    return this.http.post(this.apiUrl, message)
      .pipe(tap(_ => console.log("message sucessfully sent to api controller")));
  }

  public sendMessageToHub(message: Message) {
    var promise = this.hubConnection.invoke("BroadcastAsync", message)
      .then(() => { console.log('message sent successfully to hub'); })
      .catch((err) => console.log('error while sending a message to hub: ' + err));

    return from(promise);
  }

  private getConnection(): HubConnection {
    return new HubConnectionBuilder()
      .withUrl(this.connectionUrl)
      .withHubProtocol(new MessagePackHubProtocol())
      //  .configureLogging(LogLevel.Trace)
      .build();
  }

  private startConnection() {

    
    this.hubConnection.start()
      .then(() => console.log('connection started'))
      .catch((err) => console.log('error while establishing signalr connection: ' + err))
  }

  private addListeners() {
    let that =this;
    this.hubConnection.on("messageReceivedFromApi", (data: any) => {
      let messageLowerCase: Message = {id: data.Id, chatId: data.ChatId, activityDate: data.ActivityDate, messageText: data.MessageText, 
        userId: data.UserId, receiver : data.Receiver, user: data.User, chat: data.Chat}
      console.log("message received from API Controller")
      that.messages.push(messageLowerCase);
    })
    this.hubConnection.on("messageReceivedFromHub", (data: any) => {
      console.log("message received from Hub")
      let messageLowerCase: Message = {id: data.Id, chatId: data.ChatId, activityDate: data.ActivityDate, messageText: data.MessageText, 
        userId: data.UserId, receiver : data.Receiver, user: data.User, chat: data.Chat}
      that.messages.push(messageLowerCase);
    })
    this.hubConnection.on("newUserConnected", _ => {
      console.log("new user connected")
    })
  }
}