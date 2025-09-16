// Components
import { SelectChangeEvent } from "@mui/material";

export interface FiltersLocale {
  type: {
    label: string;
    options: FiltersTypeLocale[];
  };
  search: {
    label: string;
  };
  button: {
    label: string;
    error: string;
  };
}

export interface FiltersTypeLocale {
  value: string;
  label: string;
}

export interface UseFilters {
  type: "sell" | "rent" | "all";
  search: string;
  handleChange: (event: SelectChangeEvent) => void;
  handleChangeSearch: (event: React.ChangeEvent<HTMLInputElement>) => void;
  handleClear: () => void;
  send: () => void;
}