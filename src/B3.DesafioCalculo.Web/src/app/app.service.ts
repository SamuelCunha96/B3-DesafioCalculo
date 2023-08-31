import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AppService {
  constructor(private http: HttpClient) { }

  calcularInvestimento(valorInicial: number, prazoMeses: number): Observable<{ resultadoInvestimentoValorBruto: number, resultadoInvestimentoValorLiquido: number }> {
    const url = 'https://localhost:7283/api/';
    const body = { valorInicial, prazoMeses };

    return this.http.post<{ resultadoInvestimentoValorBruto: number, resultadoInvestimentoValorLiquido: number }>(`${url}Investimento/calcular-cdb`, body);
  }
}
