import { Message } from "./message";
import { User } from "./user";

export class Chat{
    id: number | null = null;
    name: string = "";
    users: User[] = [];
    messages: Message[] = [];
}