export interface Message{
    id: number | null;
    chatId: number;
    userId: number;
    messageText: string | null;
    activityDate: Date | null;
}