// Interfaces
import { PropertyState } from "./properties.context";

export type PropertiesActions = 
| { type: "SET_PROPERTIES"; payload: PropertyState["filters"] }
| { type: "CLEAR_FILTERS" };

export const propertiesActions = {
  ["SET_PROPERTIES"]: (state: PropertyState, payload: PropertyState["filters"]): PropertyState => {
    return {
      ...state,
      filters: payload,
    };
  },
  ["CLEAR_FILTERS"]: (state: PropertyState): PropertyState => {
    return {
      ...state,
      filters: {
        type: "all",
        search: "",
      },
    };
  },
}

