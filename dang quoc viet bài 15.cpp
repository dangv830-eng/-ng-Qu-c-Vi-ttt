#include <iostream>
#include <string>
#include <iomanip>
#include <limits>
using namespace std;


struct KhachHang {
    int maKH;           
    string tenKH;       
    string soDT;       
    double tongTien;    
};


void nhapMang(KhachHang a[], int n) {
    for (int i = 0; i < n; i++) {
        cout << "\n--- Khach hang thu " << i + 1 << " ---\n";
        cout << "Ma khach hang: ";
        cin >> a[i].maKH;
        cin.ignore(numeric_limits<streamsize>::max(), '\n');
        cout << "Ten khach hang: ";
        getline(cin, a[i].tenKH);
        cout << "So dien thoai: ";
        getline(cin, a[i].soDT);
        cout << "Tong tien thanh toan: ";
        cin >> a[i].tongTien;
    }
}


void xuatMang(const KhachHang a[], int n) {
    cout << "\n" << left << setw(8) << "Ma KH"
         << setw(25) << "Ten KH"
         << setw(15) << "So DT"
         << right << setw(15) << "Tong tien" << "\n";
    cout << string(63, '-') << "\n";
    for (int i = 0; i < n; i++) {
        cout << left << setw(8) << a[i].maKH
             << setw(25) << a[i].tenKH
             << setw(15) << a[i].soDT
             << right << setw(15) << fixed << setprecision(0) << a[i].tongTien << "\n";
    }
}

void insertionSort(KhachHang a[], int n) {
    for (int i = 1; i < n; i++) {
        KhachHang key = a[i];
        int j = i - 1;
        while (j >= 0 && a[j].tongTien > key.tongTien) {
            a[j + 1] = a[j];
            j--;
        }
        a[j + 1] = key;
    }
}

void timKiemNhiPhan(const KhachHang a[], int left, int right, double X, bool &found) {
    if (left > right) return;
    int mid = left + (right - left) / 2;
    if (a[mid].tongTien == X) {
        if (!found) {
            cout << "\nCac khach hang co tong tien thanh toan bang " << fixed << setprecision(0) << X << ":\n";
            cout << left << setw(8) << "Ma KH" << setw(25) << "Ten KH"
                 << setw(15) << "So DT" << right << setw(15) << "Tong tien" << "\n";
            cout << string(63, '-') << "\n";
        }
        found = true;
        timKiemNhiPhan(a, left, mid - 1, X, found);   
        cout << std::left << setw(8) << a[mid].maKH
             << setw(25) << a[mid].tenKH
             << setw(15) << a[mid].soDT
             << std::right << setw(15) << a[mid].tongTien << "\n";
        timKiemNhiPhan(a, mid + 1, right, X, found);  
    } else if (a[mid].tongTien < X) {
        timKiemNhiPhan(a, mid + 1, right, X, found);
    } else {
        timKiemNhiPhan(a, left, mid - 1, X, found);
    }
}


int main() {
    int n;
    do {
        cout << "Nhap so luong khach hang n: ";
        cin >> n;
    } while (n <= 0);

    KhachHang *a = new KhachHang[n];

    
    nhapMang(a, n);
    cout << "\n===== DANH SACH KHACH HANG VUA NHAP =====";
    xuatMang(a, n);

   
    insertionSort(a, n);
    cout << "\n===== DANH SACH SAU KHI SAP XEP TANG DAN THEO TONG TIEN =====";
    xuatMang(a, n);

    
    double X;
    cout << "\nNhap tong tien thanh toan X can tim: ";
    cin >> X;
    bool found = false;
    timKiemNhiPhan(a, 0, n - 1, X, found);
    if (!found) {
        cout << "\nKhong co khach hang nao co tong tien thanh toan bang " << X << "\n";
    }

    delete[] a;
    return 0;
}
