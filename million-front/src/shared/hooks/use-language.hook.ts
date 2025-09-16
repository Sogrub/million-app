// Core
import { usePathname } from "next/navigation";

// Interfaces
import { LocalAbbreviation } from "../interfaces/locale.interfaces";

export const useLanguage = (): LocalAbbreviation => {
    const pathname = usePathname();
    if (!pathname) return "en";

    const segments = pathname.split("/").filter(Boolean);
    const locale = segments[0];

    if (locale === "es" || locale === "en") {
        return locale;
    }

    return "en";
}