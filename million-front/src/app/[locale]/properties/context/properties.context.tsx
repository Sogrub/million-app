// Core
import { createContext, ReactNode, useMemo, useReducer } from "react";

// Actions
import { propertiesActions, PropertiesActions } from "./properties.actions";

export interface PropertyState {
  filters: {
    type?: "sell" | "rent" | "all";
    search?: string;
  }
}

export type ReducerPropertyFunction = (
  state: PropertyState,
  payload?: unknown,
) => PropertyState;

export interface PropertiesContextProps {
  state: PropertyState;
  dispatch: React.Dispatch<PropertiesActions>;
}

export const initialState: PropertyState = {
  filters: {
    type: "all",
    search: "",
  },
};

export const PropertiesContext = createContext<PropertiesContextProps | undefined>(undefined);

const PropertiesReducer = (
  state: PropertyState,
  action: PropertiesActions,
): PropertyState => {
  const type = action.type;
  const actionHandler = propertiesActions[type] as ReducerPropertyFunction | undefined;

  if (!actionHandler) return state;

  if ("payload" in action) {
    return actionHandler(state, action.payload);
  }
  
  return actionHandler(state);
};

export const PropertiesProvider: React.FC<{ children: ReactNode }> = ({ children }) => {
  const [state, dispatch] = useReducer(PropertiesReducer, initialState);
  const value = useMemo(() => ({ state, dispatch }), [state, dispatch]);
  return <PropertiesContext.Provider value={value}>{children}</PropertiesContext.Provider>;
}