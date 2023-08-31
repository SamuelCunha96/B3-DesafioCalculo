import { Component } from '@angular/core';
import { AppService } from './app.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'Calculo do CDB';
  valorInicial!: number;
  prazoMeses!: number;
  errorMessage!: string;
  resultadoInvestimento!: { resultadoInvestimentoValorBruto: number, resultadoInvestimentoValorLiquido: number };
  mostrarResultado!: boolean;
  constructor(private service: AppService) { }

  calcularInvestimento() {
    this.mostrarResultado = false;

    this.errorMessage = '';
    if (this.valorInicial && this.prazoMeses) {
      this.service.calcularInvestimento(this.valorInicial, this.prazoMeses)
        .subscribe({
          next: (result) => {
            this.mostrarResultado = true;
            this.resultadoInvestimento = result;
            
          },
          error: (err) => {
            console.log(err.error);
            err.error.messages.forEach((message: string) => {
              if (message != undefined) {
                this.errorMessage += message + '<br>';
              }
            })
          }
        });
    }
  }
}
