#include <iostream>
#include <string>

using namespace std;

class Node
{
public:
	Node* left;
	Node* right;
	Node* parent;
	string color;
	int key;
	Node();
	Node(int);
};

Node::Node() :key(0) {}

Node::Node(int ii) : key(ii) {}

class RBTree 
{
public:
	const Node* NIL = nullptr;
	Node* ROOT;
	void LeftRotate(Node*);
	void RightRotate(Node*);
	void Insert(Node*);
};

void RBTree::LeftRotate(Node* x)
{
	Node* y = x->right;
	x->right = y->left;
	if (y->left != NIL)
	{
		y->left->parent = x;
	}
	y->parent = x->parent;
	if (x->parent == NIL)
	{
		ROOT = y;
	}
	else if (x == x->parent->left)
	{
		x->parent->left = y;
	}
	else x->parent->right = y;
	x->left = x;
	x->parent = y;
}

void RBTree::RightRotate(Node* x)
{
	Node* y = x->left;
	x->left = y->right;
	if (y->right != NIL)
	{
		y->right->parent = x;
	}
	y->parent = x->parent;
	if (x->parent == NIL)
	{
		ROOT = y;
	}
	else if (x == x->parent->right)
	{
		x->parent->right = y;
	}
	else x->parent->left = y;
	x->right = x;
	x->parent = y;
}

void RBTree::Insert(Node* z)
{
	Node* y = nullptr;
	Node* x = ROOT;
	while (x != NIL)
	{
		y = x;
		if (z->key < x->key)
		{
			x = x->left;
		}
		else x = x->right;
	}
	z->parent = y;
	if (y == NIL)
	{
		ROOT = z;
	}
	else if (z->key < y->key)
	{
		y->left = z;
	}
	else y->right = z;
	z->left = nullptr;
	z->right = nullptr;
	z->color = "RED";
}

int main()
{

}