import { NgModule, NgModuleFactory, ModuleWithProviders } from '@angular/core';
import { CoreModule, LazyModuleFactory } from '@abp/ng.core';
import { ThemeSharedModule } from '@abp/ng.theme.shared';
import { PaymentComponent } from './components/payment.component';
import { PaymentRoutingModule } from './payment-routing.module';

@NgModule({
  declarations: [PaymentComponent],
  imports: [CoreModule, ThemeSharedModule, PaymentRoutingModule],
  exports: [PaymentComponent],
})
export class PaymentModule {
  static forChild(): ModuleWithProviders<PaymentModule> {
    return {
      ngModule: PaymentModule,
      providers: [],
    };
  }

  static forLazy(): NgModuleFactory<PaymentModule> {
    return new LazyModuleFactory(PaymentModule.forChild());
  }
}
