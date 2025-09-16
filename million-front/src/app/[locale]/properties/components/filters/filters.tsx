// Components
import { Button, FormControl, InputLabel, MenuItem, Select, TextField } from "@mui/material";

// Hooks
import { useLanguage } from "@/shared/hooks/use-language.hook";
import { useFilters } from "./hooks/use-filters.hook";

// Utils
import { t } from "@/shared/utils/translate.util";

export const Filters: React.FC = () => {
  const language = useLanguage();
  const { filters } = t(language).properties;
  const {
    type,
    search,
    handleChange,
    handleChangeSearch,
    handleClear,
    send,
  } = useFilters();

  return (
    <section className="w-full p-4">
      <div className="flex flex-col gap-4 md:flex-row">
        <FormControl variant="outlined" fullWidth>
          <InputLabel id="property-type-select-label">{filters.type.label}</InputLabel>
          <Select
            className="w-full md:w-[140px]"
            labelId="property-type-select-label"
            id="property-type-select"
            label={filters.type.label}
            value={type}
            onChange={handleChange}
          >
            {filters.type.options.map((option) => (
              <MenuItem key={option.value} value={option.value}>
                {option.label}
              </MenuItem>
            ))}
          </Select>
        </FormControl>
        <TextField
          id="search-type-select"
          label={filters.search.label}
          variant="outlined"
          value={search}
          onChange={handleChangeSearch}
          fullWidth
        />
        <Button variant="contained" color="info" onClick={send}>
          {filters.button.label}
        </Button>
        <Button variant="contained" color="error" onClick={handleClear}>
          {filters.button.error}
        </Button>
      </div>
    </section>
  );
}