import { Message } from "./message";
import { User } from "./user";

export class Chat{
    id: number | null = null;
    name: string = "";
    chatType: number = 0;
    users: User[] = [];
    messages: Message[] = [];
}