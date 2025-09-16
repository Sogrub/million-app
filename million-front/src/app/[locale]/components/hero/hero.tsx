"use client";
// Core
import Image from "next/image";
import { useEffect, useState } from "react";

// Components
import { Button, IconButton, InputBase, Paper, ToggleButton, ToggleButtonGroup } from "@mui/material";
import { Search } from "@mui/icons-material";

// Utils
import { t } from "@/shared/utils/translate.util";

// Hooks
import { useLanguage } from "@/shared/hooks/use-language.hook";
import { useNavigate } from "@/shared/hooks/use-navigate.hook";

// Constants
import { HERO_IMAGES } from "./constants/hero.constants";

export const Hero: React.FC = () => {
    const language = useLanguage();
    const { navigate } = useNavigate();
    const { title, sellText, rentText, placeholder, buttonText } = t(language).hero;
    const [currentIndex, setCurrentIndex] = useState(0);
    const [alignment, setAlignment] = useState<string | null>(null);
    const [searchValue, setSearchValue] = useState("");

    const handleChange = (
        _: React.MouseEvent<HTMLElement>,
        newAlignment: string,
      ) => {
        setAlignment(newAlignment);
    };

    const handleSubmit = () => {
        const params: Record<string, string> = {};

        if (alignment) {
            params.type = alignment;
        }

        if (searchValue) {
            params.search = searchValue;
        }
        
        console.log("🚀 ~ handleSubmit ~ params:", params)
        navigate("/properties", params);
    };

    useEffect(() => {
        const interval = setInterval(() => {
        setCurrentIndex((prev) => (prev + 1) % HERO_IMAGES.length);
        }, 5000);
        return () => clearInterval(interval);
    }, []);

    return (
        <section className="relative w-full h-[80dvh] overflow-hidden">
            {HERO_IMAGES.map((img, index) => (
                <Image
                    key={index + 1}
                    src={img}
                    alt={`Slide ${index}`}
                    width={1920}
                    height={1080}
                    className={`absolute top-0 left-0 w-full h-full object-cover transition-opacity duration-1000 ${
                        index === currentIndex ? "opacity-100" : "opacity-0"
                    }`}
                />
            ))}

            <div className="absolute top-0 left-0 w-full h-full flex flex-col gap-4 items-center justify-center">
                <h1 className="text-white text-4xl md:text-6xl font-bold text-center drop-shadow-lg">
                    {title}
                </h1>
                <ToggleButtonGroup
                    value={alignment}
                    exclusive
                    onChange={handleChange}
                    aria-label="Platform"
                    sx={{
                        "& .MuiToggleButton-root": {
                            color: "white",
                            backgroundColor: "#00000070",
                            "&.Mui-selected": {
                                color: "black",
                                backgroundColor: "white",
                            },
                        },
                    }}
                >
                    <ToggleButton value="sell">{sellText}</ToggleButton>
                    <ToggleButton value="rent">{rentText}</ToggleButton>
                </ToggleButtonGroup>
                <Paper
                    component="form"
                    onSubmit={(e) => {
                        e.preventDefault();
                        handleSubmit();
                    }}
                    sx={{ p: '2px 4px', display: 'flex', alignItems: 'center', width: 350 }}
                >
                    <InputBase
                        sx={{ ml: 1, flex: 1 }}
                        placeholder={placeholder}
                        value={searchValue}
                        inputProps={{ 'aria-label': 'search' }}
                        onChange={(e) => setSearchValue(e.target.value)}
                    />
                    <IconButton type="submit" sx={{ p: '10px' }} aria-label="search">
                        <Search />
                    </IconButton>
                </Paper>
                <Button variant="contained" color="info" onClick={handleSubmit}>
                    {buttonText}
                </Button>
            </div>
        </section>
    );
};