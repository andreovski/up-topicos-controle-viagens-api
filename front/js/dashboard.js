async function carregarDashboard() {
  const baseUrl = 'http://localhost:5199/api/viagens';
  const response = await fetch(baseUrl);
  const viagens = await response.json();

  const totalViagens = viagens.length;
  const valorTotal = viagens.reduce((soma, v) => soma + (v.preco || 0), 0);

  document.getElementById('total-viagens').textContent = totalViagens;
  document.getElementById('valor-total').textContent = valorTotal.toLocaleString('pt-BR', { style: 'currency', currency: 'BRL' });
}

window.addEventListener('DOMContentLoaded', carregarDashboard);