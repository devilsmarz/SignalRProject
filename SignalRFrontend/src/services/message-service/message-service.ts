import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Message } from 'src/models/message';
import { PageInfo } from 'src/models/pageInfo';

@Injectable({
  providedIn: 'root'
})
export class MessageService {
  apiUrl: string = "Message";
  messages: Message[] = [];

  constructor(private http: HttpClient) { }

  public sendMessage(message: Message) {
    return this.http.post(this.apiUrl, message);
  }

  public updateMessage(message: Message) {
    return this.http.put(this.apiUrl, message);
  }

  public getMessages(chatId: number, page: number | null){
    return this.http.get<PageInfo>(`${this.apiUrl}/${localStorage.getItem("userId")}/${chatId}/${page ?? ""}`);
  }

  public deleteMessage(messageId: number, chatId: number, isDeletedOnlyForCreator: Boolean){
    return this.http.delete(`${this.apiUrl}/${messageId}/${localStorage.getItem("userId")}/${chatId}/${isDeletedOnlyForCreator}`);
  }
}