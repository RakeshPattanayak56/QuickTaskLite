import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { TaskItem } from '../../models/task.model';
import { Observable, of } from 'rxjs';
import { catchError, map } from 'rxjs/operators';

@Injectable({ providedIn: 'root' })
export class TaskService {
  private apiUrl = 'https://localhost:7211/api/tasks';

  constructor(private http: HttpClient) {}

  getTasks(): Observable<TaskItem[]> {
    return this.http.get<TaskItem[]>(this.apiUrl).pipe(
      map(tasks => tasks),
      catchError(err => {
        console.error('Error fetching tasks', err);
        return of([]);
      })
    );
  }

  createTask(task: TaskItem): Observable<string> {
    return this.http.post(this.apiUrl, task, { responseType: 'text' });
  }
}