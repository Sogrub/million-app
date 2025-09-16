"use client";
// Core
import Link from "next/link";

// Hooks
import { useLanguage } from "@/shared/hooks/use-language.hook";
import { useNavigate } from "@/shared/hooks/use-navigate.hook";

// Utils
import { t } from "@/shared/utils/translate.util";

export const Footer: React.FC = () => {
  const language = useLanguage();
  const { navigate } = useNavigate();
  const { options, copyright, contactText } = t(language).footer;

  return (
    <footer className="w-full py-6 bg-gray-50 border-t border-gray-200">
    <div className="max-w-7xl mx-auto px-4 sm:px-6 lg:px-8 flex flex-col md:flex-row items-center justify-between gap-4">
      <nav className="flex gap-6 text-gray-600 font-medium">
        {options.map((option) => (
          <button key={option.text} onClick={() => navigate(option.href, option.params)} className="cursor-pointer hover:text-blue-600 transition-colors">
            {option.text}
          </button>
        ))}
        <Link href="https://wa.me/573146560105" target="_blank" className="cursor-pointer hover:text-blue-600">
          {contactText}
        </Link>
      </nav>

      <p className="text-sm text-gray-500 text-center md:text-right">
        © {new Date().getFullYear()} {copyright}
      </p>
    </div>
  </footer>
  );
}