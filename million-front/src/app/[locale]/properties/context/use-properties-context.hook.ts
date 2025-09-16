// Core
import { useContext } from "react";

// Hooks
import { PropertiesContext, PropertiesContextProps } from "./properties.context";

export const usePropertiesContext = (): PropertiesContextProps => {
  const context = useContext(PropertiesContext);
  if (!context)
    throw new Error("usePropertiesContext must be used within a PropertiesContext");
  return context;
};
