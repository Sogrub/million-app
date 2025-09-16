// Interfaces
import { Locale } from "@/shared/interfaces/locale.interfaces";

// Constants
import { HEADER_LOCALE_ES } from "@/shared/components/header/locale/locale";
import { HERO_LOCALE_ES } from "@/app/[locale]/components/hero/locale/locale";
import { BENEFITS_LOCALE_ES } from "@/app/[locale]/components/benefits/locale/locale";
import { FOOTER_LOCALE_ES } from "@/shared/components/footer/locale/locale";
import { PROPERTIES_LOCALE_ES } from "@/app/[locale]/properties/locale/locale";

export const LOCALES_ES: Locale = {
    header: HEADER_LOCALE_ES,
    hero: HERO_LOCALE_ES,
    benefits: BENEFITS_LOCALE_ES,
    footer: FOOTER_LOCALE_ES,
    properties: PROPERTIES_LOCALE_ES
}