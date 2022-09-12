import { Message } from "./message";

export interface PageInfo{
    messages: Message[];
    currentPageNumber: number;
}