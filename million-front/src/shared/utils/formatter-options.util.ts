export function formatNumberToMoney(number: number) {
  return new Intl.NumberFormat("es-ES", {
    style: "currency",
    currency: "COP",
  }).format(number);
}