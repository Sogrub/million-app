"use client";
// Core
import { Fragment, useMemo } from "react";
import Link from "next/link";

// Components
import { Close, Language, Menu as MenuIcon } from "@mui/icons-material";
import { Drawer, IconButton, Menu, MenuItem, Typography } from "@mui/material";

// Utils
import { t } from "@/shared/utils/translate.util";

// Hooks
import { useLanguage } from "@/shared/hooks/use-language.hook";

// Interfaces
import { useHeader } from "./hooks/use-header.hook";
import { useNavigate } from "@/shared/hooks/use-navigate.hook";

export const Header: React.FC = () => {
    const language = useLanguage();
    const { navigate } = useNavigate();
    const { title, menuTitle, options, contactText, languageOptions } = t(language).header;
    const {
        isMobile,
        open,
        anchorEl,
        scrolled,
        desktopMenuOpen,
        handleToggle,
        handleDesktopMenuOpen,
        handleCloseDesktopMenu,
        handleChangeLocale,
    } = useHeader();

    const optionsLanguage = useMemo(() => languageOptions.filter((lang) => lang.key !== language), [language, languageOptions]);

    return (
        <Fragment>
            <header className={
                `w-full py-4 transition-all duration-300 ${scrolled ? "fixed top-0 left-0 z-50 bg-white shadow-md" : "bg-transparent"}`
            }>
            <div className="max-w-7xl mx-auto flex items-center justify-between px-4 sm:px-6 lg:px-8">
                <Typography variant="h5">{title}</Typography>
                {!isMobile && <nav className="flex items-center gap-8 space-x-6"> 
                    {options.map((option) => (
                        <button key={option.text} onClick={() => navigate(option.href, option.params)} className="cursor-pointer hover:text-blue-600">
                            {option.text}
                        </button>
                    ))}
                    <Link href="https://wa.me/573146560105" target="_blank" className="cursor-pointer hover:text-blue-600">
                        {contactText}
                    </Link>
                    <div className="relative">
                        <IconButton
                            id="language-menu" 
                            aria-label="language" 
                            size="large" 
                            aria-controls={open ? 'language-menu' : undefined}
                            aria-haspopup="true"
                            aria-expanded={open ? 'true' : undefined}
                            onClick={handleDesktopMenuOpen}
                        >
                            <Language />
                        </IconButton>
                        <Menu
                            id="language-menu"
                            anchorEl={anchorEl}
                            open={desktopMenuOpen}
                            onClose={handleCloseDesktopMenu}
                            slotProps={{
                              list: {
                                'aria-labelledby': 'basic-button',
                              },
                            }}
                        >
                            {optionsLanguage.map((lang) => (
                                <MenuItem key={lang.key} onClick={() => handleChangeLocale(lang.key)}>{lang.text}</MenuItem>
                            ))}
                        </Menu>
                    </div>
                </nav>}
                {isMobile && <IconButton aria-label="menu" size="large" onClick={handleToggle}>
                    <MenuIcon />
                </IconButton>}
            </div>
            </header>

            <Drawer open={open} anchor="right" onClose={handleToggle} slotProps={{
                paper: {
                    className: "flex -flex-col gap-8 w-[90dvw] max-w-[350px] px-8 py-4 rounded-l-3xl",
                },
            }}>
                <header className="flex items-center justify-between">
                    <Typography variant="h6">
                        {menuTitle}
                    </Typography>
                    <IconButton aria-label="menu" size="large" onClick={handleToggle}>
                        <Close />
                    </IconButton>
                </header>
                <nav className="flex flex-col gap-8 items-center">
                    {options.map((option) => (
                        <button key={option.text} onClick={() => navigate(option.href, option.params)} className="cursor-pointer hover:text-blue-600">
                            {option.text}
                        </button>
                    ))}
                    <Link href="https://wa.me/573146560105" target="_blank" className="cursor-pointer hover:text-blue-600">
                        {contactText}
                    </Link>
                    <div className="relative">
                        <IconButton
                            id="language-menu" 
                            aria-label="language" 
                            size="large" 
                            aria-controls={open ? 'language-menu' : undefined}
                            aria-haspopup="true"
                            aria-expanded={open ? 'true' : undefined}
                            onClick={handleDesktopMenuOpen}
                        >
                            <Language />
                        </IconButton>
                        <Menu
                            id="language-menu"
                            anchorEl={anchorEl}
                            open={desktopMenuOpen}
                            onClose={handleCloseDesktopMenu}
                            slotProps={{
                              list: {
                                'aria-labelledby': 'basic-button',
                              },
                            }}
                        >
                            {optionsLanguage.map((lang) => (
                                <MenuItem key={lang.key} onClick={() => handleChangeLocale(lang.key)}>{lang.text}</MenuItem>
                            ))}
                        </Menu>
                    </div>
                </nav>
            </Drawer>
        </Fragment>
      );
};