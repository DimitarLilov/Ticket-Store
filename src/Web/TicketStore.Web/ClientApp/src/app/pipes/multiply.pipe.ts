import { Pipe, PipeTransform } from '@angular/core';

@Pipe({name: 'multiply'})
export class MultiplyPipe implements PipeTransform {
  
  transform(value: number, args: string[]): any {
    return value * Number(args);
  }
  
}