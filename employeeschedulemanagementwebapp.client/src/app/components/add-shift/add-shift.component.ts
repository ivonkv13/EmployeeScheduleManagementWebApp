import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { EmployeeRole } from '../../models/employeeRole';

@Component({
  selector: 'app-add-shift',
  templateUrl: './add-shift.component.html',
  styleUrls: ['./add-shift.component.css']
})
export class AddShiftComponent implements OnInit {
  employeeId: number;
  date: string;
  shiftForm: FormGroup;
  allEmployeeRoles: EmployeeRole[] = [];

  constructor(
    private route: ActivatedRoute,
    private fb: FormBuilder
  ) {
    this.employeeId = +this.route.snapshot.paramMap.get('employeeId')!; //THis converts the string to a number
    this.date = this.route.snapshot.paramMap.get('date')!;
    this.shiftForm = this.fb.group({
      employeeRole: ['', Validators.required],
      startTime: ['', Validators.required],
      endTime: ['', Validators.required],
    });
  }

  ngOnInit(): void {
    console.log(this.employeeId)
  }

  onSubmit(): void {
    if (this.shiftForm.valid) {
      const shiftData = {
        ...this.shiftForm.value,
        employeeId: this.employeeId,
        shiftDate: this.date,
      };

      console.log('Shift data to save:', shiftData);
    }
  }
}
