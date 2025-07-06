import { Component } from '@angular/core';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { TaskService } from '../../services/task.service';
import { TaskItem } from '../../../models/task.model';

@Component({
  selector: 'app-task-form',
  standalone: true,
  imports: [ReactiveFormsModule],
  templateUrl: './task-form.component.html'
})
export class TaskFormComponent {
  taskForm;


  constructor(private fb: FormBuilder, private taskService: TaskService) {
    this.taskForm = this.fb.group({
      title: ['', Validators.required],
      dueDate: ['', Validators.required],
      isCompleted: [false]
    });
  }
onSubmit() {
  if (this.taskForm.valid) {
    const formValue = this.taskForm.value;

    const task: TaskItem = {
      title: formValue.title ?? '',
      dueDate: formValue.dueDate ?? '',
      isCompleted: formValue.isCompleted ?? false
    };

    this.taskService.createTask(task).subscribe(msg => {
      alert(msg);
      this.taskForm.reset({ isCompleted: false });
    });
  }
}
}