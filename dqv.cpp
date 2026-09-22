#include <iostream>
#include <string>

using namespace std;

struct SinhVien {
    int maSV;          
    string tenSV;       
    string lop;
    float diemTongKet;  
    string hanhKiem;    
};

struct Node {
    SinhVien data;
    Node* left;
    Node* right;
};

void initBST(Node* &root) {
    root = NULL;
}

Node* createNode(SinhVien sv) {
    Node* newNode = new Node();
    newNode->data = sv;
    newNode->left = NULL;
    newNode->right = NULL;
    return newNode;
}


Node* insertNode(Node* root, SinhVien sv) {
    if (root == NULL) {
        return createNode(sv);
    }
    
   
    if (sv.maSV < root->data.maSV) {
        root->left = insertNode(root->left, sv);
    } else if (sv.maSV > root->data.maSV) {
        root->right = insertNode(root->right, sv);
    } else {
        cout << "Mã sinh viên " << sv.maSV << " dã t?n t?i trong cây!\n";
    }
    return root;
}


Node* searchNode(Node* root, int maSV) {
    
    if (root == NULL || root->data.maSV == maSV) {
        return root;
    }
    

    if (maSV < root->data.maSV) {
        return searchNode(root->left, maSV);
    }
    return searchNode(root->right, maSV);
}


void printSinhVien(SinhVien sv) {
    cout << "Mã SV: " << sv.maSV 
         << " | H? tên: " << sv.tenSV 
         << " | L?p: " << sv.lop 
         << " | Ði?m TK: " << sv.diemTongKet 
         << " | H?nh ki?m: " << sv.hanhKiem << endl;
}

void inOrderTraverse(Node* root) {
    if (root != NULL) {
        inOrderTraverse(root->left);
        printSinhVien(root->data);
        inOrderTraverse(root->right);
    }
}

void clearTree(Node* root) {
    if (root != NULL) {
        clearTree(root->left);
        clearTree(root->right);
        delete root;
    }
}

int main() {
    Node* root;
    initBST(root);

  
    int n;
    cout << "Nh?p s? lu?ng sinh viên n: ";
    cin >> n;

    for (int i = 0; i < n; i++) {
        SinhVien sv;
        cout << "\n--- Nh?p thông tin sinh viên th? " << i + 1 << " ---\n";
        cout << "Mã sinh viên (s? nguyên): ";
        cin >> sv.maSV;
        cin.ignore(); // Xóa b? nh? d?m bàn phím

        cout << "H? và tên: ";
        getline(cin, sv.tenSV);

        cout << "L?p: ";
        getline(cin, sv.lop);

        cout << "Ði?m t?ng k?t: ";
        cin >> sv.diemTongKet;
        cin.ignore();

        cout << "H?nh ki?m (Tot/Kha/Trung binh/Yeu): ";
        getline(cin, sv.hanhKiem);

        // Chèn sinh viên v?a nh?p vào BST
        root = insertNode(root, sv);
    }

    
    cout << "\n===========================================\n";
    cout << "DANH SÁCH T?T C? SINH VIÊN TRONG CÂY (DUY?T BST):\n";
    cout << "===========================================\n";
    if (root == NULL) {
        cout << "Cây r?ng!\n";
    } else {
        inOrderTraverse(root);
    }

    cout << "\n===========================================\n";
    int maCanTim;
    cout << "Nh?p mã sinh viên c?n tìm: ";
    cin >> maCanTim;

    Node* result = searchNode(root, maCanTim);

    if (result != NULL) {
        cout << "-> ÐÃ TÌM TH?Y SINH VIÊN:\n";
        printSinhVien(result->data);
    } else {
        cout << "-> KHÔNG CÓ SINH VIÊN CÓ MÃ " << maCanTim << " TRONG CÂY!\n";
    }

    clearTree(root);

    return 0;
}
