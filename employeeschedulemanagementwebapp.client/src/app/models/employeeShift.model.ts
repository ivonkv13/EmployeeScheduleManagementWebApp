import { EmployeeRole } from "./employeeRole";

export interface Shift {
  id: number;
  shiftDate: string;
  startTime: string;
  endTime: string;
  employeeId: number;
  employeeRoleId: number;
  employeeRole: EmployeeRole;
}