// Core
import { useRouter } from "next/navigation";

// Hooks
import { useLanguage } from "./use-language.hook";

export interface UseNavigate {
  navigate: (path: string, params?: Record<string, string>) => void;
}

export const useNavigate = (): UseNavigate => {
  const router = useRouter();
  const language = useLanguage();

  const navigate = (path: string, params: Record<string, string> = {}) => {
    const queryString = new URLSearchParams(params).toString();
    const normalizedPath = path.startsWith("/") ? path : `/${path}`;
    const url = queryString
      ? `/${language}${normalizedPath}?${queryString}`
      : `/${language}${normalizedPath}`;

    router.push(url);
  };

  return { navigate };
}