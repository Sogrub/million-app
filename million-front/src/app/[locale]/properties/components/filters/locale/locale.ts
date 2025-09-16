import { FiltersLocale } from "../interfaces/filters.interfaces";

export const FILTERS_LOCALE_ES: FiltersLocale = {
  type: {
    label: "Tipo",
    options: [
      {
        value: "all",
        label: "Tipo",
      },
      {
        value: "sell",
        label: "Venta",
      },
      {
        value: "rent",
        label: "Arriendo",
      },
    ],
  },
  search: {
    label: "Buscar",
  },
  button: {
    label: "Buscar",
    error: "Limpiar",
  },
}

export const FILTERS_LOCALE_EN: FiltersLocale = {
  type: {
    label: "Type",
    options: [
      {
        value: "all",
        label: "Type",
      },
      {
        value: "sell",
        label: "Sell",
      },
      {
        value: "rent",
        label: "Rent",
      },
    ],
  },
  search: {
    label: "Search",
  },
  button: {
    label: "Search",
    error: "Clear",
  },
}