// Core
import { useRouter, useSearchParams } from "next/navigation";
import { useEffect, useState } from "react";

// Components
import { SelectChangeEvent } from "@mui/material";

// Context
import { usePropertiesContext } from "../../../context/use-properties-context.hook";

// Interfaces
import { UseFilters } from "../interfaces/filters.interfaces";

export const useFilters = (): UseFilters => {
  const router = useRouter();
  const searchParams = useSearchParams();
  const { dispatch } = usePropertiesContext();

  const [type, setType] = useState<"sell" | "rent" | "all">("all");
  const [search, setSearch] = useState("");

  const handleChange = (event: SelectChangeEvent) => {
    const value = event.target.value as "sell" | "rent" | "all";
    setType(value);
  };

  const handleChangeSearch = (event: React.ChangeEvent<HTMLInputElement>) => {
    const value = event.target.value;
    setSearch(value);
  }

  const handleClear = () => {
    dispatch({ type: "CLEAR_FILTERS" });
    setType("all");
    setSearch("");
    const params = new URLSearchParams(searchParams.toString());
    params.delete("type");
    params.delete("search");

    router.push(`?${params.toString()}`);
  }

  const send = () => {
    const params = new URLSearchParams(searchParams.toString());
    const filter: Record<string, string> = {};

    if (type) {
      params.set("type", type);
      filter.type = type;
    }

    if (search) {
      params.set("search", search);
      filter.search = search;
    }

    dispatch({ type: "SET_PROPERTIES", payload: filter });

    router.push(`?${params.toString()}`);
  }

  useEffect(() => {
    const params = new URLSearchParams(searchParams.toString());
    const type = params.get("type");
    const searchParam = params.get("search");

    if (type) {
      setType(type as "sell" | "rent");
    } 
    
    if (searchParam) {
      setSearch(searchParam);
    }
    
    dispatch({ type: "SET_PROPERTIES", payload: { type: type as "sell" | "rent", search: searchParam as string } });
  // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [searchParams]);

  return {
    type,
    search,
    handleChange,
    handleChangeSearch,
    handleClear,
    send,
  }
}