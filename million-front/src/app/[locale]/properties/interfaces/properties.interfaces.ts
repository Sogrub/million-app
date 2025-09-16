// Interfaces
import { ContentLocale } from "../[id]/components/content/interfaces/content.interfaces";
import { FiltersLocale } from "../components/filters/interfaces/filters.interfaces";
import { ItemsLocale } from "../components/items/interfaces/items.interfaces";

export interface PropertiesLocale {
    filters: FiltersLocale;
    items: ItemsLocale;
    content: ContentLocale;
}