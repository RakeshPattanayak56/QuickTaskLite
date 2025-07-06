export interface TaskItem {
  id?: string;
  title: string;
  dueDate: string;
  isCompleted: boolean;
  statusLabel?: string;
}