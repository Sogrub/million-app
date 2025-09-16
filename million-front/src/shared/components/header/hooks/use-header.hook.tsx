// Core
import { useEffect, useState } from "react";
import { usePathname, useRouter, useSearchParams } from "next/navigation";

// Components
import { useMediaQuery } from "@mui/material";

// Interfaces
import { UseHeader } from "../interfaces/header.interfaces";
import { LocalAbbreviation } from "@/shared/interfaces/locale.interfaces";

export const useHeader = (): UseHeader => {
    const isMobile = useMediaQuery("(max-width: 768px)");
    const [open, setOpen] = useState(false);
    const [anchorEl, setAnchorEl] = useState<null | HTMLElement>(null);
    const desktopMenuOpen = Boolean(anchorEl);
    const router = useRouter();
    const pathname = usePathname();
    const searchParams = useSearchParams();
    const [scrolled, setScrolled] = useState(false);

    const handleToggle = () => {
        setOpen(!open);
    };

    const handleDesktopMenuOpen = (event: React.MouseEvent<HTMLButtonElement>) => {
        setAnchorEl(event.currentTarget);
    };

    const handleCloseDesktopMenu = () => {
        setAnchorEl(null);
    };

    const handleChangeLocale = (newLocale: LocalAbbreviation) => {
        if (!pathname) return;

        const segments = pathname.split("/").filter(Boolean);

        segments[0] = newLocale;

        const newPath = "/" + segments.join("/");

        const query = searchParams.toString();
        const finalUrl = query ? `${newPath}?${query}` : newPath;

        router.push(finalUrl);
    }

    useEffect(() => {
        const onScroll = () => setScrolled(window.scrollY > 50);
        window.addEventListener("scroll", onScroll);
        return () => window.removeEventListener("scroll", onScroll);
    }, []);

    return {
        isMobile,
        open,
        anchorEl,
        scrolled,
        desktopMenuOpen,
        handleToggle,
        handleDesktopMenuOpen,
        handleCloseDesktopMenu,
        handleChangeLocale,
    }
}