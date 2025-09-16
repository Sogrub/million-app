// Interfaces
import { LocalAbbreviation } from "@/shared/interfaces/locale.interfaces";

export interface HeaderLocale {
    title: string;
    menuTitle: string;
    options: HeaderOptionsLocale[];
    contactText: string;
    languageOptions: HeaderLanguageLocale[];
}

export interface HeaderOptionsLocale {
    text: string;
    href: string;
    params?: Record<string, string>;
}

export interface HeaderLanguageLocale {
    text: string;
    key: LocalAbbreviation;
}

export interface UseHeader {
    isMobile: boolean;
    open: boolean;
    anchorEl: null | HTMLElement;
    scrolled: boolean;
    desktopMenuOpen: boolean;
    handleToggle: () => void;
    handleDesktopMenuOpen: (event: React.MouseEvent<HTMLButtonElement>) => void;
    handleCloseDesktopMenu: () => void;
    handleChangeLocale: (newLocale: LocalAbbreviation) => void;
}