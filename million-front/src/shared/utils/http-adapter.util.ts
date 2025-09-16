import axios, { AxiosRequestConfig, Method } from "axios";

interface ApiResponse<T> {
  success: boolean;
  data?: T;
  error?: string;
}

export async function httpAdapter<T>(
  endpoint: string,
  method: Method,
  options?: {
    data?: unknown;
    params?: Record<string, unknown>;
    headers?: Record<string, string>;
  }
): Promise<ApiResponse<T>> {
  try {
    const config: AxiosRequestConfig = {
      url: endpoint,
      method,
      data: options?.data,
      params: options?.params,
      headers: options?.headers,
    };

    const response = await axios<T>(config);

    return {
      success: true,
      data: response.data,
    };
  } catch (error: unknown) {
    if (axios.isAxiosError(error)) {
      return {
        success: false,
        error: error.response?.data?.message || error.message,
      };
    }
    return {
      success: false,
      error: "Unknown error",
    };
  }
}
