import { Component, OnInit } from '@angular/core';
import { PaymentService } from '../services/payment.service';

@Component({
  selector: 'lib-payment',
  template: ` <p>payment works!</p> `,
  styles: [],
})
export class PaymentComponent implements OnInit {
  constructor(private service: PaymentService) {}

  ngOnInit(): void {
    this.service.sample().subscribe(console.log);
  }
}
