// Core
import { env } from "@/env";

// Utils
import { httpAdapter } from "../utils/http-adapter.util";

// Interfaces
import { Properties, Property } from "../interfaces/properties.interfaces";

export function getProperties(params: Record<string, string>) {
  const url = `${env.data?.NEXT_PUBLIC_API_URL}/api/Properties`;
  const { type, search } = params;

  const copyParams: Record<string, string> = {};

  if (type && type !== "all") {
    copyParams.type = type;
  }

  if (search) {
    copyParams.search = search;
  }

  return httpAdapter<Properties[]>(url, "GET", { params: copyParams });
}

export function getPropertyById(id: string) {
  const url = `${env.data?.NEXT_PUBLIC_API_URL}/api/Properties/${id}`;

  return httpAdapter<Property>(url, "GET");
}