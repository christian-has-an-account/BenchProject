import {Injectable} from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class LoggerService {
  constructor() {}

  log(message: string): void {
    const timeString: string = new Date().toLocaleDateString();
    console.log(`${message} (${timeString})`);
  }

  errorHandle(message: string): void {
    console.error(`ERROR: ${message}`);
  }
}
