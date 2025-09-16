// Interfaces
import { HeroLocale } from "@/app/[locale]/components/hero/interfaces/hero.interfaces";
import { HeaderLocale } from "../components/header/interfaces/header.interfaces";
import { BenefitsLocale } from "@/app/[locale]/components/benefits/interfaces/benefits.interfaces";
import { FooterLocale } from "../components/footer/interfaces/footer.interface";
import { PropertiesLocale } from "@/app/[locale]/properties/interfaces/properties.interfaces";

export type LocalAbbreviation = "en" | "es";

export interface Locale {
    header: HeaderLocale;
    hero: HeroLocale;
    benefits: BenefitsLocale;
    footer: FooterLocale;
    properties: PropertiesLocale;
}