"use client";
// Components
import { CheckCircle } from "@mui/icons-material";

// Hooks
import { useLanguage } from "@/shared/hooks/use-language.hook";

// Utils
import { t } from "@/shared/utils/translate.util";

export const Benefits: React.FC = () => {
    const language = useLanguage();
    const { title, items } = t(language).benefits;
    
    return (
        <section className="py-16 bg-gray-50">
            <div className="max-w-6xl mx-auto px-6">
            <h2 className="text-3xl font-bold text-center mb-12 uppercase">
                {title}
            </h2>

            <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-4 gap-8">
                {items.map((benefit) => (
                <div
                    key={benefit.title}
                    className="bg-white rounded-2xl shadow-md p-6 flex flex-col items-center text-center hover:shadow-lg transition"
                >
                    <CheckCircle className="w-10 h-10 text-blue-500 mb-4" />
                    <h3 className="text-lg font-semibold mb-2">{benefit.title}</h3>
                    <p className="text-gray-600 text-sm">{benefit.description}</p>
                </div>
                ))}
            </div>
            </div>
        </section>
    );
}