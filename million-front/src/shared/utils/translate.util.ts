// Interfaces
import { LocalAbbreviation } from "../interfaces/locale.interfaces";

// Constants
import { LOCALES_EN } from "@/locales/en";
import { LOCALES_ES } from "@/locales/es";

const LOCALES_MAP = { en: LOCALES_EN, es: LOCALES_ES };

export function t(language: LocalAbbreviation) {
    return LOCALES_MAP[language];
}