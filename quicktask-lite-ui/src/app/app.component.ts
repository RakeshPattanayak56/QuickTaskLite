import { Component } from '@angular/core';
import { TaskFormComponent } from './app/components/task-form/task-form.component';
import { TaskListComponent } from './app/components/task-list/task-list.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [TaskFormComponent, TaskListComponent],
  template: `
    <h1>QuickTask Lite</h1>
    <app-task-form></app-task-form>
    <app-task-list></app-task-list>
  `
})
export class AppComponent {}