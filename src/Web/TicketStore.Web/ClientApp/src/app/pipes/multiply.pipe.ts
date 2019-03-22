import { Pipe, PipeTransform } from '@angular/core';

@Pipe({name: 'multiply'})
export class MultiplyPipe implements PipeTransform {
  
  transform(value: string, args: string[]): any {
    return value * args;
  }
  
}