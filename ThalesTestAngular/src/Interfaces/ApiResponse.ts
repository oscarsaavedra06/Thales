import { Employees } from './Employees';

export interface ApiResponse {
    status: string,
    code: number,
    data: any,
    message: string
}