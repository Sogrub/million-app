// Interfaces
import { Locale } from "@/shared/interfaces/locale.interfaces";

// Constants
import { HEADER_LOCALE_EN } from "@/shared/components/header/locale/locale";
import { HERO_LOCALE_EN } from "@/app/[locale]/components/hero/locale/locale";
import { BENEFITS_LOCALE_EN } from "@/app/[locale]/components/benefits/locale/locale";
import { FOOTER_LOCALE_EN } from "@/shared/components/footer/locale/locale";
import { PROPERTIES_LOCALE_EN } from "@/app/[locale]/properties/locale/locale";

export const LOCALES_EN: Locale = {
    header: HEADER_LOCALE_EN,
    hero: HERO_LOCALE_EN,
    benefits: BENEFITS_LOCALE_EN,
    footer: FOOTER_LOCALE_EN,
    properties: PROPERTIES_LOCALE_EN
}