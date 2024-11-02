#include <iostream>
#include <string>
using namespace std;

int main() {
    int N, K;
    cin >> N >> K; // N: N�mero de d�gitos, K: N�mero de d�gitos a remover

    string Num; // N�mero a operar
    cin >> Num;

    // La longitud deseada del n�mero final es N - K
    int digits_to_keep = N - K;
    string result = "";

    for (int i = 0; i < N; ++i) {
        // Mientras el resultado no est� vac�o y podamos eliminar m�s d�gitos
        // y el �ltimo d�gito en el resultado sea menor que el d�gito actual
        // y a�n podamos alcanzar la longitud deseada del resultado
        while (!result.empty() && K > 0 && result.back() < Num[i] && result.length() + (N - i - 1) >= digits_to_keep) {
            result.pop_back();
            --K;
        }
        result.push_back(Num[i]);
    }

    // Si a�n queda alg�n d�gito para eliminar, lo hacemos desde el final
    while (K > 0) {
        result.pop_back();
        --K;
    }

    // Imprimir el resultado final
    cout << result << endl;

    return 0;
}