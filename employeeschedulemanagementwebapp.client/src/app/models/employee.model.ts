import { EmployeeRole } from "./employeeRole";
import { Shift } from "./employeeShift.model";

export interface Employee {
    id: number;
    name: string;
    employeeRoles: EmployeeRole[];
    shifts: Shift[];
  }
  